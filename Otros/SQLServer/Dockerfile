FROM mcr.microsoft.com/mssql/server:2019-latest
# Create work directory
RUN mkdir -p /usr/work
WORKDIR /usr/work
# Copy all scripts into working directory
COPY . /usr/work/
# Grant permissions for the import-data script to be executable
#RUN chmod 775 /usr/work/import-data.sh
EXPOSE 1433
#ENTRYPOINT ["/opt/mssql-tools/bin/sqlcmd", "-S", "localhost","-U","SA","-P",PIC@1234,"-i","setup.sql"]
#CMD /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "PIC@1234" -i setup.sql
