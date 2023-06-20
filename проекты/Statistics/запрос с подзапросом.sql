select dirName, depName, pNum, pText,  CAST(COUNT(cid) as varchar) + '/' + CAST ((select COUNT(mID) from 
Conclutions as c2 left join Letters on (c2.lID = Letters.lID)
left join MaterialLetter on (Letters.lID = MaterialLetter.lID)
left join ItemsOfPlan on (Letters.pID = ItemsOfPlan.pID)
left join Operatives on (c2.opID = Operatives.opID)
left join Departments on (Operatives.depID = departments.depID)
left join Directions on (Departments.dirID = Directions.dirID)
where c1.cID = c2.cID
group by dirName, depName, pNum, pText) as varchar)
from 
Conclutions  as c1 left join Letters on (c1.lID = Letters.lID)
left join ItemsOfPlan on (Letters.pID = ItemsOfPlan.pID)
left join Operatives on (c1.opID = Operatives.opID)
left join Departments on (Operatives.depID = departments.depID)
left join Directions on (Departments.dirID = Directions.dirID)
group by dirName, depName, ItemsOfPlan.pID, pNum, pText
order by dirName, depName, ItemsOfPlan.pID

select dirName, depName, pNum, pText, CAST(COUNT(cid) as varchar) + '/' + CAST ((select COUNT(mID) from 
Conclutions left join Letters on (Conclutions.lID = Letters.lID)
left join MaterialLetter on (Letters.lID = MaterialLetter.lID)
left join ItemsOfPlan as p2  on (Letters.pID = p2.pID)
left join Operatives on (Conclutions.opID = Operatives.opID)
left join Departments dep2 on (Operatives.depID = dep2.depID)
left join Directions  dir2 on (dep2.dirID = dir2.dirID)
where (p1.pID = p2.pID) and (dep1.depID = dep2.depID) and (dir1.dirID = dir2.dirID)
group by dir2.dirID, dirName, dep2.depID, depName, p2.pID, pNum, pText) as varchar) 
from 
Conclutions left join Letters on (Conclutions.lID = Letters.lID)
left join ItemsOfPlan as p1 on (Letters.pID = p1.pID)
left join Operatives on (Conclutions.opID = Operatives.opID)
left join Departments dep1 on (Operatives.depID = dep1.depID)
left join Directions dir1 on (dep1.dirID = dir1.dirID)
group by dir1.dirID, dirName, dep1.depID, depName, p1.pID, pNum, pText
order by dirName, depName, p1.pID


select dirName, depName, COUNT(cid) 
from Conclutions left join Letters on (Conclutions.lID = Letters.lID)
left join Operatives on (Conclutions.opID = Operatives.opID)
left join Departments dep1 on (Operatives.depID = dep1.depID)
left join Directions dir1 on (dep1.dirID = dir1.dirID)
group by dirName, depName
order by dirName, depName

select dirName, depName, COUNT(mid) 
from Conclutions left join Letters on (Conclutions.lID = Letters.lID) 
left join MaterialLetter on (Letters.lID = MaterialLetter.lID)
left join Operatives on (Conclutions.opID = Operatives.opID) 
left join Departments dep2 on (Operatives.depID = dep2.depID)
left join Directions  dir2 on (dep2.dirID = dir2.dirID)
group by dirName, depName
order by dirName, depName

select dirName, depName, CAST(COUNT(cid) as varchar) + '/' + CAST (
(select COUNT(mid) 
from Conclutions left join Letters on (Conclutions.lID = Letters.lID) 
left join MaterialLetter on (Letters.lID = MaterialLetter.lID)
left join Operatives on (Conclutions.opID = Operatives.opID) 
left join Departments dep2 on (Operatives.depID = dep2.depID)
left join Directions  dir2 on (dep2.dirID = dir2.dirID)
where (dep1.depID = dep2.depID) and (dir1.dirID = dir2.dirID)
group by dir2.dirID, dirName, dep2.depID, depName) as varchar)
from Conclutions left join Letters on (Conclutions.lID = Letters.lID)
left join Operatives on (Conclutions.opID = Operatives.opID)
left join Departments dep1 on (Operatives.depID = dep1.depID)
left join Directions dir1 on (dep1.dirID = dir1.dirID)
group by dir1.dirID, dirName, dep1.depID, depName
order by dirName, depName