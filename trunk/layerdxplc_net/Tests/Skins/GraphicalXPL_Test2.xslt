<?xml version="1.0" encoding="UTF-8" ?>
<!--

    HOJA DE TRANSFORMACIÓN XSLT PARA FORMATEO DE CÓDIGO ZOE.
    
    VERSIÓN: 1.0
    
    POR ALEXIS FERREYRA.
    
    Para información sobre el lenguaje ZOE y la tecnología LayerD
    por favor visite http://layerd.net.
    
-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="XPLDocument">
    <html>
      <style>
        body{font-family:Courier New;}
        b.showmembers{font-size: 9pt;cursor: pointer;}
        b.Modifier{color:darkgreen;}
        b.typename{color:Maroon;}
        b.NamespaceKW,b.Keyword,b.ClassKW,b.EnumKW,b.InterfaceKW,b.StructKW
        {color:navy;}
        td.NamespaceMembers{
        border-width:1px;
        border-color:darkgrey;
        border-style:solid;
        background-color:aliceblue;
        padding-right:10px;
        }
        td.ClassMembers{
        background-color: ghostwhite;
        margin-left:10px;
        padding-left:10px;
        padding-right:10px;
        }
      </style>
      <script>
        <![CDATA[
          function mostrarMembers2(obj,obj2){
            if(obj.style.display=='none')
		          {obj.style.display='block';obj2.firstChild.nodeValue='-';}
		        else
		          {obj.style.display='none';obj2.firstChild.nodeValue='+';}
  			  }        
          function mostrarFB(obj,obj2){
            while(obj.nodeName.toLowerCase()!="div")obj=obj.nextSibling;
            if(obj.style.display=='none')
		          {obj.style.display='block';obj2.firstChild.nodeValue='-';}
		        else
		          {obj.style.display='none';obj2.firstChild.nodeValue='+';}
  			  }        
          function mostrarNSMembers(obj,obj2){
            while(obj.nodeName.toLowerCase()!="table")obj=obj.nextSibling;
            if(obj.style.display=='none')
		          {obj.style.display='block';obj2.firstChild.nodeValue='Hide Namespace Members';
              }
		        else
		          {obj.style.display='none';obj2.firstChild.nodeValue='Show Namespace Members';}
  			  }        
        ]]>
      </script>
      <head></head>
      <body>
        <table>
          <dr>
            <dt>
              <xsl:apply-templates select="DocumentData"></xsl:apply-templates>
            </dt>
          </dr>
          <dr>
            <dt>
              <xsl:apply-templates select="DocumentBody"></xsl:apply-templates>
            </dt>
          </dr>
        </table>
      </body>
    </html>
  </xsl:template>
  <xsl:template match="DocumentBody">
    <xsl:apply-templates select="Import"></xsl:apply-templates>
    <xsl:apply-templates select="Using"></xsl:apply-templates>
    <br/>
    <table>
      <xsl:apply-templates select="Namespace">
        <xsl:sort select="@name"/>
      </xsl:apply-templates>
      <xsl:apply-templates select="Class">
        <xsl:sort select="@name"/>
      </xsl:apply-templates>
    </table>
  </xsl:template>
  <xsl:template match="Import">
    <b class="Keyword">Importar </b>
    <xsl:for-each select="ns">
      "<xsl:apply-templates></xsl:apply-templates>"
      <xsl:if test="position()!=last()">, </xsl:if>
    </xsl:for-each>
    ;<br/>
  </xsl:template>
  <xsl:template match="Using">
    <b class="Keyword">Usar </b>
    <xsl:for-each select="ns">
      "<xsl:apply-templates></xsl:apply-templates>"
      <xsl:if test="position()!=last()">, </xsl:if>
    </xsl:for-each>
    ;<br/>
  </xsl:template>
  <xsl:template match="Namespace">
    <tr>
      <td>
        <b class="NamespaceKW">Paquete </b><xsl:value-of select="@name"/> :
        <b class="showmembers"
          onmouseover="this.style.color='firebrick';this.style.textDecoration='underline';"
          onmouseout="this.style.color='black';this.style.textDecoration='none';"
         onclick="mostrarNSMembers(this,this)">Mostrar Miembros</b>
        <br/>
        <table style="DISPLAY: NONE;">
          <tr>
            <td class="NamespaceMembers">
              <table  style="table-layout: fixed">
                <xsl:apply-templates select="Class" >
                  <xsl:sort select="@name"/>
                </xsl:apply-templates>
                <tr>
                  <td></td>
                  <td>
                    <table>
                      <xsl:apply-templates select="Namespace">
                        <xsl:sort select="@name"/>
                      </xsl:apply-templates>
                    </table>
                  </td>
                </tr>
              </table>
            </td>
          </tr>
        </table>
      </td>
    </tr>
  </xsl:template>
  <xsl:template match="Class">
    <tr>
      <td style="width: 10px">
        <b class="showmembers"
          onmouseover="this.style.color='firebrick';this.style.textDecoration='underline';"
          onmouseout="this.style.color='black';this.style.textDecoration='none';"
          onclick="mostrarMembers2(this.parentNode.parentNode.nextSibling,this);">+</b>
      </td>
      <td >
        <xsl:choose>
          <xsl:when test="@isinterface">
            <b class="InterfaceKW">Interfaz </b>
          </xsl:when>
          <xsl:when test="@isstruct">
            <b class="StructKW">Estructura </b>
          </xsl:when>
          <xsl:when test="@isenum">
            <b class="EnumKW">Enumeracion </b>
          </xsl:when>
          <xsl:otherwise>
            <b class="ClassKW">Clase </b>
          </xsl:otherwise>
        </xsl:choose>
        <xsl:value-of select="@name"/> :
        <xsl:choose>
          <xsl:when test="@access!=''">
            <b class="Modifier">
              <xsl:value-of select="@access"/>
              <xsl:text xml:space="preserve"> </xsl:text>
            </b>
          </xsl:when>
          <xsl:otherwise>
            <b class="Modifier">Privada  </b>
          </xsl:otherwise>
        </xsl:choose>
        <xsl:if test="@isfactory">
          <b class="Modifier">Factory </b>
        </xsl:if>
        <xsl:if test="@isinteractive">
          <b class="Modifier">Interactiva </b>
        </xsl:if>
        <xsl:if test="@abstract">
          <b class="Modifier">Abstracta </b>
        </xsl:if>
        <xsl:if test="@final">
          <b class="Modifier">Final </b>
        </xsl:if>
        <xsl:if test="@extension">
          <b class="Modifier">Extension </b>
        </xsl:if>
        <xsl:if test="@new">
          <b class="Modifier">Nueva </b>
        </xsl:if>
      </td>
    </tr>
    <tr  style="DISPLAY: none;">
      <td style="width: 10px">
      </td>
      <td>
        <table>
          <tr>
            <td class="ClassMembers">
              <table style="table-layout: fixed">
                <xsl:apply-templates select="Inherits"></xsl:apply-templates>
                <xsl:apply-templates select="Implements"></xsl:apply-templates>
                <xsl:apply-templates select="SetPlatforms"></xsl:apply-templates>
                <xsl:apply-templates select="AutoInstance"></xsl:apply-templates>
                <xsl:apply-templates select="Field">
                  <xsl:sort select="@name"/>
                </xsl:apply-templates>
                <xsl:apply-templates select="Property">
                  <xsl:sort select="@name"/>
                </xsl:apply-templates>
                <xsl:apply-templates select="Function">
                  <xsl:sort select="@name"/>
                </xsl:apply-templates>
                <xsl:apply-templates select="Indexer">
                  <xsl:sort select="@name"/>
                </xsl:apply-templates>
                <xsl:apply-templates select="Operator">
                  <xsl:sort select="@name"/>
                </xsl:apply-templates>
              </table>
            </td>
          </tr>
        </table>
      </td>
    </tr>
  </xsl:template>
  <xsl:template match="Inherits">

  </xsl:template>
  <xsl:template match="Implements">

  </xsl:template>
  <xsl:template match="SetPlatforms">

  </xsl:template>
  <xsl:template match="AutoInstance">

  </xsl:template>
  <xsl:template match="BeginCFPermissions"></xsl:template>
  <xsl:template match="EndCFPermissions"></xsl:template>

  <xsl:template name="RenderType">
    <xsl:if test="@ispointer">
      <!--
      <xsl:if test="pi/@ref">
        <xsl:text xml:space="default">^</xsl:text>
      </xsl:if>
      -->
      <xsl:if test="not(pi/@ref)">
        <xsl:text xml:space="default">*</xsl:text>
      </xsl:if>
      <xsl:apply-templates select="dt">
      </xsl:apply-templates>
    </xsl:if>
    <xsl:if test="@isarray">
      <xsl:text xml:space="default">[]</xsl:text>
      <xsl:apply-templates select="dt">
      </xsl:apply-templates>
    </xsl:if>
    <xsl:if test="not(@isarray) and not(@isponter)">
      <xsl:choose>
        <xsl:when test="@typename='$VOID$'">
          <xsl:text>void</xsl:text>
        </xsl:when>
        <xsl:when test="@typename='$BYTE$'">
          <xsl:text>byte</xsl:text>
        </xsl:when>
        <xsl:when test="@typename='$SHORT$'">
          <xsl:text>short</xsl:text>
        </xsl:when>
        <xsl:when test="@typename='$INTEGER$'">
          <xsl:text>int</xsl:text>
        </xsl:when>
        <xsl:when test="@typename='$LONG$'">
          <xsl:text>long</xsl:text>
        </xsl:when>
        <xsl:when test="@typename='$SBYTE$'">
          <xsl:text>byte</xsl:text>
        </xsl:when>
        <xsl:when test="@typename='$USHORT$'">
          <xsl:text>ushort</xsl:text>
        </xsl:when>
        <xsl:when test="@typename='$UNSIGNED$'">
          <xsl:text>uint</xsl:text>
        </xsl:when>
        <xsl:when test="@typename='$ULONG$'">
          <xsl:text>ulong</xsl:text>
        </xsl:when>
        <xsl:when test="@typename='$FLOAT$'">
          <xsl:text>float</xsl:text>
        </xsl:when>
        <xsl:when test="@typename='$DOUBLE$'">
          <xsl:text>double</xsl:text>
        </xsl:when>
        <xsl:when test="@typename='$LDOUBLE$'">
          <xsl:text>ldouble</xsl:text>
        </xsl:when>
        <xsl:when test="@typename='$DECIMAL$'">
          <xsl:text>decimal</xsl:text>
        </xsl:when>
        <xsl:when test="@typename='$BOOLEAN$'">
          <xsl:text>bool</xsl:text>
        </xsl:when>
        <xsl:when test="@typename='$CHAR$'">
          <xsl:text>char</xsl:text>
        </xsl:when>
        <xsl:when test="@typename='$ASCIICHAR$'">
          <xsl:text>ASCIIChar</xsl:text>
        </xsl:when>
        <xsl:when test="@typename='$STRING$'">
          <xsl:text>string</xsl:text>
        </xsl:when>
        <xsl:when test="@typename='$ASCIISTRING$'">
          <xsl:text>ASCIIString</xsl:text>
        </xsl:when>
        <xsl:when test="@typename='$DATETIME$'">
          <xsl:text>DateTime</xsl:text>
        </xsl:when>
        <xsl:when test="@typename='$OBJECT$'">
          <xsl:text>object</xsl:text>
        </xsl:when>
        <xsl:when test="@typename='$TYPE$'">
          <xsl:text>type</xsl:text>
        </xsl:when>
        <xsl:when test="@typename='$BLOCK$'">
          <xsl:text>block</xsl:text>
        </xsl:when>
        <xsl:otherwise>
          <xsl:value-of select="@typename"/>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:if>
  </xsl:template>
  <xsl:template match="dt|type|ReturnType|Type">
    <xsl:call-template name="RenderType"></xsl:call-template>
  </xsl:template>

  <xsl:template match="Parameters">
    <xsl:for-each select="P">
      <xsl:call-template name="RenderParameter"></xsl:call-template>
      <xsl:if test="position()!=last()">, </xsl:if>
    </xsl:for-each>
  </xsl:template>
  <xsl:template name="RenderParameter">
    <b class="typename">
      <xsl:apply-templates select="type"></xsl:apply-templates>
    </b>
    <xsl:text xml:space="default"> </xsl:text>
    <xsl:value-of select="@name"/>
  </xsl:template>

  <xsl:template match="Function|Operator">
    <tr>
      <td width="10px">
        <xsl:if test="FunctionBody">
          <b class="showmembers"
            onmouseover="this.style.color='firebrick';this.style.textDecoration='underline';"
            onmouseout="this.style.color='black';this.style.textDecoration='none';"
            onclick="mostrarMembers2(this.parentNode.parentNode.nextSibling,this);">+</b>
        </xsl:if>
      </td>
      <td>
        <b class="Modifier">
          <xsl:value-of select="@access"/>
        </b>
        <b class="Keyword"> Funcion </b>
        <xsl:value-of select="@name"/>
        <b> (</b>
        <xsl:apply-templates select="Parameters"></xsl:apply-templates>
        <b>) : </b>
        <b class="typename">
          <xsl:apply-templates select="ReturnType"></xsl:apply-templates>
        </b>
      </td>
    </tr>
    <xsl:if test="FunctionBody">
      <tr style="display: none;">
        <td></td>
        <td>
          <xsl:apply-templates select="FunctionBody"></xsl:apply-templates>
        </td>
      </tr>
    </xsl:if>
  </xsl:template>

  <xsl:template match="Indexer">
    <tr>
      <td width="10px">
        <xsl:if test="FunctionBody">
          <b class="showmembers"
            onmouseover="this.style.color='firebrick';this.style.textDecoration='underline';"
            onmouseout="this.style.color='black';this.style.textDecoration='none';"
            onclick="mostrarMembers2(this.parentNode.parentNode.nextSibling,this);">+</b>
        </xsl:if>
      </td>
      <td>
        <b class="Modifier">
          <xsl:value-of select="@access"/>
        </b>
        <b class="Keyword"> Indexador </b>
        <b> [</b>
        <xsl:apply-templates select="Parameters"></xsl:apply-templates>
        <b>] : </b>
        <b class="typename">
          <xsl:apply-templates select="ReturnType"></xsl:apply-templates>
        </b>
      </td>
    </tr>
    <xsl:if test="FunctionBody">
      <tr style="display: none;">
        <td></td>
        <td>
          <xsl:apply-templates select="FunctionBody"></xsl:apply-templates>
        </td>
      </tr>
    </xsl:if>
  </xsl:template>

  <xsl:template match="Field">
    <tr>
      <td width="10px">
      </td>
      <td>
        <b class="Modifier">
          <xsl:value-of select="@access"/>
        </b>
        <b class="Keyword"> Campo </b>
        <xsl:value-of select="@name"/>
        <b>: </b>
        <b class="typename">
          <xsl:apply-templates select="type"></xsl:apply-templates>
        </b>
        <br/>
      </td>
    </tr>
  </xsl:template>

  <xsl:template match="Property">
    <tr>
      <td width="10px">
      </td>
      <td>
        <b class="Modifier">
          <xsl:value-of select="@access"/>
        </b>
        <b class="Keyword"> Propiedad </b>
        <xsl:value-of select="@name"/>
        <b>: </b>
        <b class="typename">
          <xsl:apply-templates select="Type"></xsl:apply-templates>
        </b>
        <br/>
      </td>
    </tr>
  </xsl:template>

  <xsl:template match="FunctionBody|bk">
    <table  style="table-layout: fixed;">
      <tr>
        <td style="width: 10px"></td>
        <td>
          <b class="Keyword">Inicio</b>
          <br/>
          <table  style="table-layout: fixed">
            <tr>
              <td style="width: 10px"></td>
              <td>
                <xsl:apply-templates></xsl:apply-templates>
              </td>
            </tr>
          </table>
          <b class="Keyword">Fin</b>
          <br/>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!-- INSTRUCCIONES -->
  <xsl:template match="Decls">
    <b class="Keyword">Vars</b>
    <b>;</b>
    <br/>
  </xsl:template>
  <!-- FIN INSTRUCCIONES -->
</xsl:stylesheet>