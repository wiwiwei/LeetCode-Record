/*查询多列 */
SELECT device_id,gender,age,university FROM user_profile
/*查询所有列 */
SELECT* FROM user_profile
/* 查询数据单列去重 */
SELECT DISTINCT university FROM user_profile 
/*限制查询数据条数 Mysql*/
SELECT device_id FROM user_profile LIMIT 2
/*限制查询数据条数 SQL Server*/
SELECT Top 2 device_id FROM user_profile 