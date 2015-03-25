# Meta D++ reserved keywords #

Current implementation of Meta D++ compiler defines the following keywords:

```
ASCIIChar
ASCIIString
abstract
alias
autoinstance
block
blocktofactorys
bool
break
bycall
bycallto
byclass
bynamespace
byte
case
catch
char
class
const
continue
decimal
default
delete
do
double
else
enum
except
exec
exp
expression
expressionlist
extension
extern
factory
final
finally
float
for
force
foreach
fp
get
gettype
identifiers
if
implements
import
in
iname
indexer
inherits
inout
int
interactive
interface
iprivate
iprotected
ipublic
is
keyword
like
long
namespace
new
nonvirtual
object
operator
ordinary
out
override
params
private
property
protected
public
readonly
ref
resume
return
sbyte
set
setplatforms
short
sizeof
statement
static
string
struct
switch
throw
try
type
typeof
uint
ulong
union
unsigned
ushort
using
virtual
void
volatile
while
writecode
```

You can't use those keywords as identifier. If you want to use one keyword as identifier you must use "@" symbol before the word, for example:

```
// keywords used as identifiers
int @int = 1;
float @class = 2;
int n = 3;

@class = @int + @class + n;

```

**Note:** list of keywords for future revisions of Meta D++ compiler is expected to be reduced.