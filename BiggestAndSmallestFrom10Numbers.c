#include<stdio.h>
void max_min(int a[], int size, int * max, int * min);

int main() {
    int nums[10];
    int input;

    for (int i = 0; i < 10; i++){
        scanf("%d", &input);
        nums[i] = input;
    }

    int variable;
    int variable1;
    int *max = &variable;
    *max = -1000;

    int *min = &variable1;
    *min = 1000;

    max_min(nums, 10, max, min);

    printf("%d, %d", *max, *min);

    return 0;
}

void max_min(int a[], int size, int * max, int * min) {
    for (int i = 0; i < size; i++) {
        if (a[i] > *max) {
            *max = a[i];
        }
        if (a[i] < *min) {
            *min = a[i];
        }
    }
}