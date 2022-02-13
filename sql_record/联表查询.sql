/*嵌套where查询*/
select device_id,question_id,result FROM question_practice_detail
WHERE device_id in
(SELECT device_id FROM user_profile WHERE university = '浙江大学')
/*表连接查询*/
select qpd.device_id,qpd.question_id,qpd.result FROM question_practice_detail as qpd
inner JOIN user_profile as up on up.device_id = qpd.device_id and up.university = '浙江大学'