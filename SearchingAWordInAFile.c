#include<stdio.h>
#include<string.h>
#include<stdbool.h>
#include<unistd.h>

int main() {
    FILE *fp;
    char buff[255];
    char fileName[100];
    char str[100];
    int lineNum = 0;
    bool inCheck;
    bool toBreak;

    scanf("%s", fileName);

    while (!(access(fileName, F_OK) == 0)) {
        printf("File doesn't exist! Please type another file name: ");
        scanf("%s", fileName);
    }

    fp = fopen(fileName, "r");
    scanf("%s", str);

    int z = 0;
    int startL = -1;
    int startC = -1;
    while (!toBreak) {

        if (fgets(buff,255, fp) == NULL) break;
        lineNum++;

        for (int i = 0; i < strlen(buff); i++) {
            if ((char)buff[i] == (char)str[z]) {
                inCheck = 1;
                if (startL == -1 && startC == -1) {
                    startL = lineNum;
                    startC = i;
                }
                if ((z == strlen(str) - 1) && inCheck) {
                    toBreak = 1;
                    break;
                }
                z++;
            } else {
                inCheck = 0;
                startL = -1;
                startC = -1;
                z = 0;
            }
        }
    }
    
    startL == -1 ? printf("No such string found in the file.\n") : printf("Line: %d\n", startL);
    startL == -1 ? printf("") : printf("Column: %d\n", startC);
    fclose(fp);
    return 0;
}