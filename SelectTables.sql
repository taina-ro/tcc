-- Tenta simular o quadro da página 103 (parcial)

Select  ci.Circuito_Descr as 'Circuito',
		l.Local_Descr as 'Local',
		ci.Circuito_Tensao as 'Tensao',
        c.Carga_Pot  as 'Potencia',
		(Select SUM(c1.Carga_Pot)
		 from Carga as c1
		 join Circuito as ci1 on ci1.Circuito_ID = c1.Circuito_ID 
		 where c1.Circuito_ID = c.Circuito_ID ) as 'Pot. Total',
		 (Select 1.0 * SUM(c1.Carga_Pot)
		 from Carga as c1
		 join Circuito as ci1 on ci1.Circuito_ID = c1.Circuito_ID 
		 where c1.Circuito_ID = c.Circuito_ID ) / ci.Circuito_Tensao as 'Corrente Total'
from 
Carga as c
join Ponto as p on p.Ponto_ID = c.Ponto_ID
join Local as l on l.Local_ID = p.Local_ID
join Circuito as ci on ci.Circuito_ID = c.Circuito_ID
order by 1,2

