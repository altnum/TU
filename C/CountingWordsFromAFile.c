#include<stdio.h>
#include<string.h>
#include<stdbool.h>
#include<unistd.h>

int main() {
    FILE *fp;
    char buff[255];
    char fileName[100];

    scanf("%s", fileName);

    while (!(access(fileName, F_OK) == 0)) {
        printf("File doesn't exist! Please type another file name: ");
        scanf("%s", fileName);
    }

    fp = fopen(fileName, "r");
    
    int count = 0;

    while (1) {

        if (fgets(buff,255, fp) == NULL) break;
        bool inWord = 0;

        for (int i = 0; i < strlen(buff); i++) {
            if (((char) buff[i] >= 65 && (char) buff[i] <= 90) || ((char) buff[i] >= 97 && (char) buff[i] <= 122)) {
                if (!inWord) {
                    inWord = 1;
                    count++;
                }
            } else {
                inWord = 0;
            }
        }
    }

    printf("Number of words found in the file: %d\n", count);
    fclose(fp);
    return 0;
}