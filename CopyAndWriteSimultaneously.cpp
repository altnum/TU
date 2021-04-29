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
#include <iostream>
#include <fstream>
using namespace std;

bool fin = false;

pthread_mutex_t mtx;
pthread_cond_t varcond;

struct data_t {
    char buff[512];
};

void * task_b(void * d) {
    data_t * b_data = (data_t *)d;
    pthread_mutex_lock(&mtx);
    pthread_cond_wait(&varcond, &mtx);
    while (!fin) {
        printf("bam\n");

        printf("bam\n");
        fstream my_new_file;
        my_new_file.open("test2.txt", ios::app);
        my_new_file << b_data->buff;
        my_new_file.close();
        pthread_mutex_unlock(&mtx);
        pthread_cond_signal(&varcond);
        pthread_mutex_lock(&mtx);
        pthread_cond_wait(&varcond, &mtx);
        printf("bam\n");
    }
    pthread_exit(0);

    return NULL;
}

int main (int argc, char * argv[]) {
    data_t data;
    memset(&data, 0, sizeof(data));
    pthread_t h_thread = 0;

    data_t * a_data = (data_t *)&data;
    pthread_create(&h_thread, NULL, task_b, &data);

    int h_file = ::open("test.txt", O_RDONLY);



    ssize_t end = 1;
    
    while (end != 0) {
        memset(a_data->buff, 0, 512);
        ssize_t size_read = ::read(h_file, a_data->buff, 512);
        printf("bum\n");
        end = size_read;
        pthread_mutex_unlock(&mtx);
        pthread_cond_signal(&varcond);
        pthread_cond_wait(&varcond, &mtx);
        printf("bum\n");

    }
    printf("1bum\n");
    fin = true;
    pthread_mutex_unlock(&mtx);
    pthread_cond_signal(&varcond);
    pthread_join(h_thread, NULL);
    fflush(stdout);

    return 0;
    
}