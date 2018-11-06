# Aster 

# Moving project to node from dotNet

## Requirements
Node
Docker
Docker Compose 
Webpack

## Quick Start


## Database
For development database can be served from docker for quick up and running. 

### MySql/MariaDB Backup

```sh
docker exec <CONTAINER> /usr/bin/mysqldump -u root --password=root DATABASE > backup.sql
```


### Restore
```sh
cat backup.sql | docker exec -i <CONTAINER> /usr/bin/mysql -u root --password=root DATABASE
```
