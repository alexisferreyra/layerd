# replace with your binaries
ZOEC = C:\facu\layerd\trunk\layerdxplc_net\bin\Debug\zoec.exe
METADPP = C:\facu\layerd\trunk\layerdxplc_net\bin\Debug\metadppc.exe

DEPENDENCIES_ZOE = \
                default.externs.zoe \
                pacman.zoe \
                pacman.controller.zoe \
                pacman.map.zoe \
                pacman.actor.zoe \
                pacman.soul.zoe \
                pacman.bad.zoe \
                pacman.good.zoe

all: $(DEPENDENCIES_ZOE)
	mkdir output & echo Generate JS
	$(ZOEC) -p:Javascript -opath:output pacman.zoe

%.zoe: %.dpp
	$(METADPP) -s $<

clean:
	del *.zoe
	rmdir /S /Q output
