#ifndef _yacc_defines_h_
#define _yacc_defines_h_

#define PC_IMPORT 257
#define PC_USING 258
#define PC_IDENTIFIERS 259
#define PC_ALIAS 260
#define PC_NAMESPACE 261
#define PC_CLASS 262
#define PC_ENUM 263
#define PC_UNION 264
#define PC_INTERFACE 265
#define PC_INHERITS 266
#define PC_IMPLEMENTS 267
#define PC_VIRTUAL 268
#define PC_NONVIRTUAL 269
#define PC_SETPLATFORMS 270
#define PC_LIKE 271
#define PC_AUTOINSTANCE 272
#define PC_BYCALL 273
#define PC_BYCLASS 274
#define PC_BYNAMESPACE 275
#define PC_BYCALLTO 276
#define PC_FPOINTER 277
#define PC_CONSTRUCTOR 278
#define PC_PUBLIC 279
#define PC_PROTECTED 280
#define PC_PRIVATE 281
#define PC_IPUBLIC 282
#define PC_IPROTECTED 283
#define PC_IPRIVATE 284
#define PC_STATIC 285
#define PC_CONST 286
#define PC_VOLATILE 287
#define PC_EXTERN 288
#define PC_FORCE 289
#define PC_FACTORY 290
#define PC_INTERACTIVE 291
#define PC_KEYWORD 292
#define PC_FINAL 293
#define PC_NEW 294
#define PC_OVERRIDE 295
#define PC_ABSTRACT 296
#define PC_PARAMS 297
#define PC_IN 298
#define PC_OUT 299
#define PC_INOUT 300
#define PC_REF 301
#define PC_EXTENSION 302
#define PC_ORDINARY 303
#define PC_STRUCT 304
#define PC_OPERATOR 305
#define PC_INDEXER 306
#define PC_PROPERTY 307
#define PC_GET 308
#define PC_EZOEICIT 309
#define PC_READONLY 310
#define PC_BLOCKTOFACTORYS 311
#define PC_EXCEPT 312
#define PC_SET 313
#define PC_RESUME 314
#define PC_BREAK 315
#define PC_CONTINUE 316
#define PC_SELECTOUTPUT 317
#define PC_WRITECODE 318
#define PC_IF 319
#define PC_ELSE 320
#define PC_WHILE 321
#define PC_DO 322
#define PC_FOR 323
#define PC_SWITCH 324
#define PC_CASE 325
#define PC_DEFAULT 326
#define PC_RETURN 327
#define PC_THROW 328
#define PC_TRY 329
#define PC_CATCH 330
#define PC_FINALLY 331
#define PC_STATIC_CAST 332
#define PC_DYNAMIC_CAST 333
#define PC_DELETE 334
#define PC_BOOL 335
#define PC_VOID 336
#define PC_OBJECT 337
#define PC_SBYTE 338
#define PC_SHORT 339
#define PC_INT 340
#define PC_LONG 341
#define PC_UNSIGNED 342
#define PC_BYTE 343
#define PC_USHORT 344
#define PC_UINT 345
#define PC_ULONG 346
#define PC_FLOAT 347
#define PC_DOUBLE 348
#define PC_DECIMAL 349
#define PC_CHAR 350
#define PC_ASCII_CHAR 351
#define PC_STRING 352
#define PC_ASCII_STRING 353
#define PC_TYPE 354
#define PC_BLOCK 355
#define PC_EXPRESSION 356
#define PC_EXPRESSIONLIST 357
#define PC_INAME 358
#define PC_STATEMENT 359
#define PC_SIZEOF 360
#define PC_TYPEOF 361
#define PC_GETTYPE 362
#define PC_EXEC 363
#define PC_IS 364
#define PC_IMPLICIT 365
#define USER_TYPE_NAME 366
#define OPEN_PARENTESIS 367
#define CLOSE_PARENTESIS 368
#define OPEN_LLAVE 369
#define CLOSE_LLAVE 370
#define OPEN_CORCHETE 371
#define CLOSE_CORCHETE 372
#define PUNTO_COMA 373
#define COMA 374
#define PUNTO 375
#define OP_COMILLA 376
#define OP_IGUAL 377
#define OP_MAYOR 378
#define OP_MENOR 379
#define OP_ADMIRACION 380
#define OP_CELDILLA 381
#define OP_PREGUNTA 382
#define OP_DOSPUNTOSDOBLE 383
#define OP_DOSPUNTOS 384
#define OP_IGUALIGUAL 385
#define OP_MENORIGUAL 386
#define OP_MAYORIGUAL 387
#define OP_ADMIRACIONIGUAL 388
#define OP_YY 389
#define OP_OO 390
#define OP_MASMAS 391
#define OP_MENOSMENOS 392
#define OP_MAS 393
#define OP_MENOS 394
#define OP_ASTERISCO 395
#define OP_DIVIDIDO 396
#define OP_Y 397
#define OP_O 398
#define OP_SOMBRERO 399
#define OP_PORCENTAJE 400
#define OP_SHIFTLEFT 401
#define OP_SHIFTRIGHT 402
#define OP_SHIFTRIGHT_JAVA 403
#define OP_MASIGUAL 404
#define OP_MENOSIGUAL 405
#define OP_ASTERISCOIGUAL 406
#define OP_DIVIDIDOIGUAL 407
#define OP_YIGUAL 408
#define OP_OIGUAL 409
#define OP_SOMBREROIGUAL 410
#define OP_PORCENTAJEIGUAL 411
#define OP_SHIFTLEFTIGUAL 412
#define OP_SHIFTRIGHTIGUAL 413
#define OP_SHIFTRIGHT_JAVA_IGUAL 414
#define OP_IGUALMAYOR 415
#define OP_MENOSMAYOR 416
#define OP_MENOSMAYORASTERISCO 417
#define OP_PUNTOASTERISCO 418
#define NULL_LITERAL 419
#define BOOLEAN_LITERAL_TRUE 420
#define BOOLEAN_LITERAL_FALSE 421
#define CHARACTER_LITERAL 422
#define STRING_LITERAL 423
#define INTEGER_LITERAL 424
#define FLOAT_LITERAL 425
#define DECIMAL_LITERAL 426
#define WHITE_SPACE 427
#define COMENTARIO_LARGO 428
#define COMENTARIO 429
#define IDENTIFICADOR 430
#define ERROR_LEXICO 431
#define MAL_CARACTER 432
#define ERROR_COMILLA 433
#define YYERRCODE 256

typedef union {
	CodeDOM::XplNode* node;
	CodeDOM::XplExpression* exp;
	CodeDOM::XplNodeList* list;
	CodeDOM::XplNode* nodos[4];
	CodeDOM::XplLiteral* literal;
	unsigned int num;
	DOM_CHAR str[1024];
} YYSTYPE;
extern YYSTYPE yylval;

#endif
