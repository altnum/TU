#include <locale.h>
#include <stdlib.h>
#include <string.h>
#include <stdio.h>
#include <wchar.h>
#include <pthread.h>
#include <errno.h>
#include <fcntl.h>
#include <unistd.h>
#include <sys/stat.h>
#include <stdint.h>
#include <cstdio>
#include <cassert>

#define OK 0
#define FAIL -1

#ifndef _ERRNO_T
#define _ERRNO_T
typedef int                    errno_t;
#endif  /* _ERRNO_T */



pthread_mutex_t mtx;
pthread_cond_t varcond;\
bool fin = false;

struct data_t {
    uint32_t * data;
    uint32_t sum;
    size_t count;
    errno_t status;
};

void * task_b(void * d) {
    while (!fin) {
        pthread_mutex_lock(&mtx);
        pthread_cond_wait(&varcond, &mtx);

        data_t * data = (data_t *)d;
        if (data->status)
        {
        	printf("error while reading file  %u %s\n", data->status, strerror(data->status));
        	pthread_exit(0);
        }

        size_t i = 0;

        for (i = 0; i < data->count; i++)
        {
        	data->sum += data->data[i];
        }
        pthread_cond_signal(&varcond);
        pthread_mutex_unlock(&mtx);

    }
    pthread_exit(0);
    return NULL;
}
//2. TASK B waits signal from A
//4. takes signal from A
//6. signals A to continue
//8. When everything is read B quits

int main(int argc, char * argv[]) {
    // create shared data object
	data_t data;
	memset(&data, 0, sizeof(data));

    pthread_t h_thread = 0;


    //1. START TASK B;
    errno_t b_err = pthread_create(&h_thread, NULL, task_b, &data);
    //3. opens file and signals B
    data_t * p_data = (data_t *)&data;

    if (!&p_data)
	{
		return 1;
	}

    int h_file = ::open("test.txt", O_RDONLY);
    
    char block[512];

    ssize_t end = 1;

    while (end != 0) {
	    p_data->status = errno;

        if (h_file < 0)
	    {
	    	printf("cannot open file  %u %s  %s\n", p_data->status, strerror(p_data->status), "test.txt");
	    	return 1;
	    }

        struct stat s;

	    p_data->status = fstat(h_file, &s);

        if (p_data->status != OK)
	    {
	    	printf("cannot determine file size  %u %s  %s\n", p_data->status, strerror(p_data->status), "test.txt");
	    	return 1;
	    }

        p_data->count = s.st_size ? 512 : 0;
	    p_data->data = (uint32_t *)malloc(p_data->count + 512);
	    memset(p_data->data, 0, p_data->count);

        ssize_t size_read = ::read(h_file, p_data->data, 512);

	    // close file
        end = size_read;
        pthread_mutex_unlock(&mtx);
        pthread_cond_signal(&varcond);
        pthread_cond_wait(&varcond, &mtx);
        //5. waits for B
    }
    fin = true;
    pthread_cond_signal(&varcond);
    pthread_mutex_unlock(&mtx);
    ::close(h_file);
    //7. THis continues till err or end of file
    //9. A waits for B and quits
    pthread_join(h_thread, NULL);
    printf("checksum %08x\n", data.sum);
    fflush(stdout);

	// free resources
	if (data.data)
	{
		free(data.data);
		data.data = NULL;
	}

    return 0;
}