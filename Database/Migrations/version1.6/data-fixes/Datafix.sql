--Adjust STUDENT_ADMISSION is_active as per facilities

--Reset all
update STUDENT_ADMISSION set stam_is_active = 0

--Set where cource is active
merge into STUDENT_ADMISSION a
using(
	select STFL_ADMISSION_NO,STFL_PACKAGE_ID,count(1) ct
	from STUDENT_FACILITIES 
	where STFL_STATUS in ('R','A')
	group by STFL_ADMISSION_NO,STFL_PACKAGE_ID  
  )facility
on(facility.STFL_ADMISSION_NO = a.STAM_ADMISSION_NO and facility.STFL_PACKAGE_ID = stam_package_id and ct > 0)
when matched then
update set stam_is_active = 1;