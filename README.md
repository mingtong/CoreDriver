
### Install .NET Core on CentOS
```
sudo rpm -Uvh https://packages.microsoft.com/config/rhel/7/packages-microsoft-prod.rpm
sudo yum update
sudo yum install dotnet-sdk-2.2
```
Or manually download from https://dotnet.microsoft.com/download/dotnet-core/2.2

## Create model .cs file using exsiting database

For example a sqlite database has 2 tables.

' dotnet ef dbcontext scaffold "Data Source = DataSource//CoreDriver.db" Microsoft.EntityFrameworkCore.Sqlite --output-dir Models
