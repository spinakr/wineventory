

#Setup dns to match docker container, needed when running dev servers
Add "127.0.0.1 postgres" to your "/private/etc/hosts"-file and flush the dns settings with `dscacheutil -flushcache`

# List files in directory in container·
docker exec -it winer_db_1 ls /var/opt/mssql/data/

# Copy file from container·
docker cp winer_db_1:/var/opt/mssql/data/winer-2018127-10-20-1.bak .