/*嵌套where查询*/
select device_id,question_id,result FROM question_practice_detail
WHERE device_id in
(SELECT device_id FROM user_profile WHERE university = '浙江大学')
/*表连接查询*/
select qpd.device_id,qpd.question_id,qpd.result FROM question_practice_detail as qpd
inner JOIN user_profile as up on up.device_id = qpd.device_id and up.university = '浙江大学'

SELECT up.university,Count(qpd.question_id)/Count(DISTINCT(qpd.device_id))
FROM user_profile as up JOIN question_practice_detail as qpd on up.device_id = qpd.device_id
GROUP BY up.university 

/* 多表连接查询 */
SELECT up.university,qpd.difficult_level,COUNT(qpd.question_id)/Count(DISTINCT(qpd.device_id)) as avg_answer_cnt 
from user_profile as up join 
(SELECT b.difficult_level,a.question_id,a.device_id 
 from question_practice_detail as a JOIN question_detail as b on a.question_id=b.question_id) as qpd
on up.device_id=qpd.device_id 
GROUP BY up.university,qpd.difficult_level

SELECT
u.university,
qd.difficult_level,
count(q.question_id)/count(distinct(q.device_id)) AS avg_answer_cnt
FROM question_practice_detail AS q
LEFT JOIN user_profile AS u
ON u.device_id=q.device_id
LEFT JOIN question_detail AS qd
ON q.question_id=qd.question_id
GROUP BY u.university, qd.difficult_level;

/*不去重*/
SELECT device_id,gender,age,gpa from user_profile
WHERE university= '山东大学' 
union all
SELECT device_id,gender,age,gpa from user_profile
WHERE gender='male'
/* 计算25岁以上和以下的用户数量 */
SELECT CASE WHEN age<25 or age IS NULL THEN '25岁以下'
            WHEN age >= 25 THEN '25岁及以上'
            END  as age_cut,COUNT(*) as number
FROM user_profile
GROUP BY age_cut

SELECT IF(age<25 OR age IS NULL,'25岁以下','25岁以及上') age_cut,COUNT(device_id) Number
FROM user_profile
GROUP BY age_cut