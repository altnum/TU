#include<stdio.h>
#include<string.h>
#include<pthread.h>

int turn = 1;
pthread_mutex_t mtx;
pthread_cond_t varcond;

void* th(void *vargp) {
    pthread_mutex_lock(&mtx);
    if (turn == 1) {
        int i = 1;
        while (i <= 9) {
            printf("th1:%d\n", i);
            i += 2;
        }
        turn = 2;
        pthread_mutex_unlock(&mtx);

        pthread_exit(0);
    }
    if (turn == 2) {
        int i = 2;
        while (i <= 10) {
            printf("th2:%d\n", i);
            i += 2;
        }
        turn = 1;
        pthread_mutex_unlock(&mtx);
        pthread_exit(0);
    }
}

void* thread1(void *vargp) {
    int i = 1;

    pthread_mutex_lock(&mtx);
    while (i<=9) {
        while (turn != 1) {
            pthread_cond_wait(&varcond, &mtx);
        }

        turn = 2;
        printf("th1:%d\n", i);
        i = i + 2;
        pthread_cond_signal(&varcond);
        pthread_mutex_unlock(&mtx);
        
    }

    pthread_exit(0);
}

void* thread2(void *vargp) {
    int i = 2;

    pthread_mutex_lock(&mtx);
    while (i <= 10) {
        while (turn != 2) {
            pthread_cond_wait(&varcond, &mtx);
        }

        turn = 1;
        printf("th2:%d\n", i);
        i = i + 2;
        pthread_cond_signal(&varcond);
        pthread_mutex_unlock(&mtx);
        
    }

    pthread_exit(0);
}

int main() {
    pthread_mutex_init(&mtx, NULL);
    char input[4];
    scanf("%s", input);

    while (1) {
        if (strcmp(input, "i") == 0) {
            pthread_t th1, th2;
            pthread_create(&th1, NULL, *th, NULL);
            pthread_create(&th2, NULL, *th, NULL);
            pthread_join(th2, NULL);
        } else if (strcmp(input, "ii") == 0) {
            pthread_t th1, th2;
            pthread_create(&th1, NULL, *thread1, NULL);
            pthread_create(&th2, NULL, *thread2, NULL);
            pthread_join(th2, NULL);
        } else if (strcmp(input, "exit") == 0) {
            break;
        }
        printf("\n");
        scanf("%s", input);
    }
    
    return 0;
}