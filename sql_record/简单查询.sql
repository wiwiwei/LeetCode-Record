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
/* 将查询后的列重新命名 AS关键字*/
SELECT device_id as user_infos_example FROM user_profile Limit 2
/* 简单的where查找*/
SELECT device_id,university FROM user_profile WHERE(university='北京大学')
SELECT device_id,gender,age,university FROM user_profile WHERE(age>24)
SELECT device_id,gender,age FROM user_profile WHERE(age<=23 AND age >=20)
SELECT device_id,gender,age,university FROM user_profile where(university!='复旦大学')
SELECT device_id,gender,age,university FROM user_profile where age is not null
SELECT device_id,gender,age,university,gpa FROM user_profile where gender='male' and gpa> 3.5
SELECT device_id,gender,age,university,gpa FROM user_profile where university='北京大学' or gpa> 3.7
SELECT device_id,gender,age,university,gpa FROM user_profile where university IN ('北京大学','复旦大学','山东大学')
SELECT device_id,gender,age,university,gpa FROM user_profile 
where (university = '山东大学' and gpa>3.5 )
or (university = '复旦大学' and gpa>3.8)
/*模糊匹配*/
SELECT device_id,age,university FROM user_profile 
where university like '%北京%'
/*查询最大值*/
SELECT Max(gpa) as gpa FROM user_profile
where university='复旦大学'
select gpa from user_profile
where university='复旦大学'
order by gpa desc limit 1
/* 计算男生人数以及平均GPA */
select Count(gender) as male_num,AVG(gpa) as avg_gpa
from user_profile 
WHERE(gender = 'male')
/* 分组计算 */
SELECT gender,university,
COUNT(id) as user_num,
AVG(active_days_within_30) as avg_active_day,
AVG(question_cnt) as avg_question_cnt
from user_profile
GROUP BY gender , university
