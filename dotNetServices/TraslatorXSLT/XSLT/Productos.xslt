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
						<th>Codigo</th>
						<th>Fabricante</th>
						<th>TipoProveedor</th>
						<th>CodigoProveedor</th>
						<th>Nombre</th>
						<th>Descripcion</th>
						<th>Categoria</th>
						<th>Precio</th>
						<th>Inventario</th>
					</tr>
					<xsl:for-each select="productos/producto">
						<xsl:sort select="Precio" order="descending"/>
						<tr>
							<td>
								<xsl:value-of select="@Codigo"/>
							</td>
							<td>
								<xsl:value-of select="Fabricante"/>
							</td>
							<td>
								<xsl:value-of select="TipoProveedor"/>
							</td>
							<td>
								<xsl:value-of select="CodigoProveedor"/>
							</td>
							<td>
								<xsl:value-of select="Nombre"/>
							</td>
							<td>
								<xsl:value-of select="Descripcion"/>
							</td>
							<td>
								<xsl:value-of select="Categoria"/>
							</td>
							<td>
								<xsl:value-of select="Precio"/>
							</td>
							<td>
								<xsl:value-of select="Inventario"/>
							</td>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
