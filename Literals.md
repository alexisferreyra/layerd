# Literals #

Literals in Meta D++ follow C/C++/C# family of languages:

## Numbers ##

```
// unsigned integers
int a = 1233432444;
// octal
a = 0888;
// hex
a = 0xFFFF;

long b = 1233213324l;
b = 12L;

// floating point
float v1 = 45.6f;
double v2 = 12.332333;

v2 = 12E+120;
v2 = 12E-120;

```

## Strings and char ##

```
string^ mystr = "Hello world\n\n\"Earth\"";
char a = 'e';
a = '\"';
```

## Booleans ##

```
bool flag = true;
flag = false;
```

## Null ##

```
// use null or NULL
string^ var = null;
int* var2 = NULL;
```