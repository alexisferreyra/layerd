# replace with your binaries
ZOEC = C:\facu\layerd\trunk\layerdxplc_net\bin\Debug\zoec.exe
METADPP = C:\facu\layerd\trunk\layerdxplc_net\bin\Debug\metadppc.exe

DEPENDENCIES_ZOE = \
                default.externs.zoe \
                hello_world.zoe

all: $(DEPENDENCIES_ZOE)
	mkdir html & echo Generate JS
	$(ZOEC) -p:Javascript -opath:html hello_world.zoe

%.zoe: %.dpp
	$(METADPP) -s $<

clean:
	del *.zoe
	rmdir /S /Q html
