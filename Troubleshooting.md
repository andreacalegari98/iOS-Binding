** Problem 1 **

``` Undefined symbols for architecture arm64:
      "_OBJC_CLASS_$_ObjectBuilder", referenced from:
         -u command line option
    ld: symbol(s) not found for architecture arm64
    clang : error : linker command failed with exit code 1 (use -v to see invocation)
```

** Solution 1 **
This is happening because ObjectBuilder is not declared into the static library, so add it in XCode.
<br><br>
** Problem 2 **
``` java exited with code 2 ``` (more or less)

** Solution 2 **
Enable Multi-Dex
