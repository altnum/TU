#include<stdio.h>
#include<string.h>
#define MIN(x, y) (((x) < (y)) ? (x) : (y))

int main() {
    char line[25][1000];
    int i = 0;
    int k;
    while(1) {
        char input[1000];
        scanf ("%[^\n]%*c", input);
        if (strcmp(input, "end") == 0 || i == 25) {
            break;
        }
        strcpy(line[i], input);
        i++;
    }

    for(int y = 0; y < 24; y++) {
        for(int z = 0; z < 23 - y; z++) {
            for(int chars = 0; chars < MIN(strlen(line[z]), strlen(line[z+1])); chars++) {
                int a = line[z][chars];
                int b = line[z+1][chars];
                if (a > b) {
                    char temp[1000];
                    strcpy(temp, line[z]);
                    strcpy(line[z], line[z+1]);
                    strcpy(line[z+1], temp);
                    break;
                }
            }
        }
    }

    for(int j = 0; j < 25; j++) {
        if (!*line[j]){
            break;
        }
        printf("%s\n", line[j]);
    }

    return 0;
}