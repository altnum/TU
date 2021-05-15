#include <stdio.h>
 #include <memory.h>
 #include <unistd.h>
 #include <sys/mman.h>
 #include <sys/stat.h>
 #include <sys/types.h>
 #include <stdlib.h>
 #include <fcntl.h>

 void filecpy(char src[], char dest[]) {
    FILE *f1;
    f1 = fopen(src, "r"); 
    FILE *f2;
    f2 = fopen(dest, "w+");

    if (f1 == NULL || f2 == NULL) {
        printf("An error occurred while opening files.");
        exit(EXIT_FAILURE);
    }

    off_t s = lseek(fileno(f1), 0, SEEK_END);
    lseek(fileno(f1), 0, SEEK_SET);

    char * c = malloc(s);

    if (read(fileno(f1), c, s) == s)
        write(fileno(f2), c, s);

    free(c);

    fclose(f1);
    fclose(f2);
 }

 int main(int argc, char**argv) {
    char path[100];
    struct stat stats;
    printf("Enter source file path: ");
    scanf("%s", path);

    if (stat(path, &stats) == 0) {
        printf("size: %d\n", (int)stats.st_size);
    }

    int wordlen = 0;

    for (int i = strlen(path); i > 0; i--) {
        if (path[i] == 47) {
            break;
        }

        wordlen++;
    }
    char *fpath2 = malloc(strlen(path) - wordlen + 1);

    memcpy(fpath2, &path, strlen(path) - wordlen + 1);
    fpath2[strlen(path) - wordlen] = '\0';

    char name2[100];
    char res[100];
    res[0] = '\0';
    strcat(res, "/");
    
    printf("Enter new file name with extension: ");
    scanf("%s", name2);
    strcat(res, name2);
    char *result = malloc(strlen(fpath2) + strlen(res) + 1);
    strcpy(result, fpath2);
    strcat(result, res);
    printf("%s", result);

    FILE *dest;
    dest = fopen(result, "w+");

    int num = ftruncate(fileno(dest), stats.st_size);

    fclose(dest);


    filecpy(path, result);

    return 0;
 }
