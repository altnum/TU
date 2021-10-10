#include<stdio.h>
#include<dirent.h>
#include<string.h>
#include <sys/stat.h>
#include <sys/types.h>
#include <time.h>
#include<stdlib.h>

char dirName[] = "";
int offset = 1;

void explorer(char *path) {
    struct dirent *de;
    struct stat fileStat;
    struct tm * timeInfo;

    DIR *dr = opendir(path);

    if (dr == NULL)
    {
        printf("Could not open current directory.");
    }

    while ((de = readdir(dr)) != NULL)
    {
        if (strcmp(de->d_name, ".") && strcmp(de->d_name, "..")) {
            for(int i = 1; i < offset + 1; i++) {
                printf(">>>");
            }
            if (de->d_type == 4)
                printf("%s-DIRECTORY\n", de->d_name);
            else {
                printf("%s\n", de->d_name);
                char newDirName[255];
                newDirName[0] = '\0';
                strcat(newDirName, path);
                strcat(newDirName, "/");
                strcat(newDirName, de->d_name);
                stat(newDirName, &fileStat);
                printf("File Permissions: \t");
                printf( (fileStat.st_mode & S_IROTH) ? "R" : "-");
                printf( (fileStat.st_mode & S_IWOTH) ? "W" : "-");
                printf( (fileStat.st_mode & S_IRUSR) ? "Can be read by owner" : "-");
                printf("\n\n");

                time_t now = time(0);
                time_t lastChange = fileStat.st_mtime;
                time_t diff = now - lastChange;

                double seconds1 = difftime(now, lastChange);
                int check = diff / 86400;
                if (check <= 10 && check >= 0) {
                    char buff[20];
                    time_t lastA = fileStat.st_atime;
                    strftime(buff, 20, "%Y-%m-%d %H:%M:%S", localtime(&lastA));
                    printf("Last access time: %s\n", buff);
                }
                printf("\n");
            }
        }
        if (de->d_type == 4 && strlen(de->d_name) != 1 && strlen(de->d_name) != 2) {
            char newPathy[255];
            newPathy[0] = '\0';
            strcat(newPathy, path);
            strcat(newPathy, "/");
            strcat(newPathy, de->d_name);
            char *ptr = newPathy;
            offset++;
            explorer(ptr);
            offset--;
        }
    }  

    closedir(dr);
}

int main()
{
    scanf("%s", dirName);
    char *ptr = dirName;
    explorer(ptr);
    return 0;
}