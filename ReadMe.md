# ImportCsvData

This console application allowed me to import my csv data into my MS SQL database. The database stores my sedimentological data and has the following tables: 
- SampleOverview 
- GrainSize 
- Petrography 
- XrdMineralogy
- XrfMainElements
- XrfMinorElements

For every sample a 'Sample Overview' entry has to be generated befor adding data to any other table.

The headers of each csv table can be changed in the accompanying json file. The filepath has to be given as an argument to each database import


### Example
> ImportCsvData.exe -o E:/Overview.csv

> Data successfully imported!

### Import options
```
    -a <path-to-xrfMainElements-file>        Add new xrf main elements data.        
    -g <path-to-grainSize-file>              Add new grain size data.
    -i <path-to-xrfMinorElements-file>       Add new xrf minor elements data.
    -o <path-to-overview-file>               Add new sample overviews to the database.
    -p <path-to-petrography-file>            Add new petrography data.
    -x <path-to-xrdMineralogy-file>          Add new xrd mineralogy data.
```

