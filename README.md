# Cine+

Proyecto final de Ingeniería de Software, [la orientación](https://evea.uh.cu/mod/resource/view.php?id=11766) del proyecto se encuentra en el EVEA.

## Acerca de la documentación

Toda la documentación se va a desarrollar en Markdown.

No se incluyen en el repositorio los `.pdf` de la documentación ni la orden del proyecto para ahorrar los megas. 

Para generar los `.pdf`, debe tener pandoc, y ejecutar el script `export.sh` incluido en `/doc/`, debe introducir el fichero `.md` y el nombre final del `.pdf`. Ejemplo:

```
./export.sh Somm97.md "Especificación de Requerimientos.pdf"
```

Esto genera una carpeta `doc/paper` con el `.pdf` en su interior.

### Requerimientos

Las extensiones de VS Code para trabajar  con `.md` son:

* Markdown All in One
* Markdown Preview Enhanced
* Office Viewer (con esta pueden abrir cualquier archivo de Microsoft Office desde el code, y tiene soporte para `.md`)
* Markdownlint

Todas las anteriores son buenas, usen la que les venga en gana.

Para exportar de `.md` a `.pdf` o `.tex` deben tener pandoc, para instalarlo puede descargarlo desde acá:

* [Instalador de pandoc para Windows (20 MB)](https://github.com/jgm/pandoc/releases/download/2.13/pandoc-2.13-windows-x86_64.msi)




# Desarrolladores

* Carlos Toledo Silva ([@cts-crypto](https://github.com/cts-crypto))
* Aylín Álvarez Santos ([@chains99](https://github.com/chains99))
* Ariel Alfonso Triana Pérez ([@ArielTriana](https://github.com/ArielTriana))
* Rocio Ortiz Gancedo ([@rocioog00](https://github.com/rocioog00))