LEX:=flex
BTYACC:=btyacc
LEXER_NAME:=layerd_dpp_lexer_beta
PARSER_NAME:=layerd_dpp_parser_beta

all:$(LEXER_NAME).c $(PARSER_NAME)_tab.c

$(LEXER_NAME).c: $(LEXER_NAME).l
	$(LEX) -8 -o$(LEXER_NAME).c $(LEXER_NAME).l

$(PARSER_NAME)_tab.c: $(PARSER_NAME).y
	$(BTYACC)  -dv -b $(PARSER_NAME) $(PARSER_NAME).y

.PHONY:clean

clean:
	rm $(COMPILER_NAME) $(PARSER_NAME)_tab.c $(LEXER_NAME).c


