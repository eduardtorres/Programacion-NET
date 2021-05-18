<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
				xmlns:msxsl="urn:schemas-microsoft-com:xslt"
				exclude-result-prefixes="msxsl">
	<xsl:output method="html" indent="yes"/>
	<xsl:template match="/">
		<html>
			<body>
				<h2>Productos</h2>
				<table border="1">
					<tr bgcolor="#a0a0ff">
						<th>Id</th>
						<th>Codigo</th>
						<th>Fabricante</th>
						<th>TipoProveedor</th>
						<th>CodigoProveedor</th>
						<th>Nombre</th>
						<th>Descripcion</th>
						<th>Categoria</th>
						<th>Imagen</th>
						<th>Precio</th>
						<th>Moneda</th>
						<th>Inventario</th>
					</tr>
					<xsl:for-each select="productos/producto">
						<xsl:sort select="precio" order="descending"/>
						<tr>
							<td>
								<xsl:value-of select="@id"/>
							</td>
							<td>
								<xsl:value-of select="@codigo"/>
							</td>
							<td>
								<xsl:value-of select="proveedor"/>
							</td>
							<td>
								<xsl:value-of select="tipoProveedor"/>
							</td>
							<td>
								<xsl:value-of select="codigoProveedor"/>
							</td>
							<td>
								<xsl:value-of select="nombre"/>
							</td>
							<td>
								<xsl:value-of select="descripcion"/>
							</td>
							<td>
								<xsl:value-of select="categoria"/>
							</td>
							<td>
								<xsl:value-of select="imagen"/>
							</td>
							<td>
								<xsl:value-of select="precio"/>
							</td>
							<td>
								<xsl:value-of select="moneda"/>
							</td>
							<td>
								<xsl:value-of select="inventario"/>
							</td>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
