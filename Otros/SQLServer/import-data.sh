# wait for the SQL Server to come up
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "PIC@1234" -i setup.sql
# import the data from the csv file
#/opt/mssql-tools/bin/bcp PICA.dbo.TB_CONTROL in "/usr/work/TB_CONTROL.csv" -c -t',' -S localhost -U SA -P "PIC@1234" -d heroes