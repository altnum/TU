 #include <stdio.h>
 #include <memory.h>
 #include <unistd.h>
 #include <sys/mman.h>
 #include <sys/stat.h>
 #include <stdlib.h>

 static size_t SYSTEM_PAGE_SIZE = 0;

 void mm_init() {
     SYSTEM_PAGE_SIZE = getpagesize();
 }

 static void * mm_get_new_vm_page_from_kernel(int units) {
     char *vm_page = mmap(0, units * SYSTEM_PAGE_SIZE, PROT_READ|PROT_WRITE|PROT_EXEC,
        MAP_ANON|MAP_PRIVATE, 0, 0);

    if(vm_page == MAP_FAILED) {
        printf("Error : VM Page allocation Failed\n");
        return NULL;
    }
    memset(vm_page, 0, units * SYSTEM_PAGE_SIZE);
    return(void *)vm_page;
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

    printf("%s", fpath2);
    char name2[100];
    char res[100];
    res[0] = '\0';
    strcat(res, "/");
    
    printf("Enter new file name: ");
    scanf("%s", name2);
    strcat(res, name2);
    char *result = malloc(strlen(fpath2) + strlen(res) + 1);
    strcpy(result, fpath2);
    strcat(result, res);
    printf("%s", result);

    FILE *fp;
    fp = fopen(result, "w+");

    int num = ftruncate(fileno(fp), stats.st_size);

    fclose(fp);

    //function to copy memory from the first file to the new one (like memcpy())
    return 0;
 }