use AirlinesDatabase

select
	*
from travel t
inner join way w on t.wayid = w.id
inner join Airport a on w.AirportId = a.Id
inner join City c on a.CityId = c.Id
inner join Airport ad on w.AirportDestinyId = ad.Id
inner join City cd on ad.CityId = cd.Id
inner join TravelFlight tf on tf.TravelId = t.Id
inner join Flight f on tf.FlightId = f.Id
inner join Airline ar on f.AirlineId = ar.Id
where 1=1
and t.id in (1,3)

select * from [dbo].[TravelFlight] where TravelId = 1

select
	ti.Description,
	ti.TravelId,	
	ti.Price,
	(count(f.id)-1) 'Stop'
from ticket ti
inner join travel t on ti.TravelId = t.id
inner join way w on t.wayid = w.id
inner join Airport a on w.AirportId = a.Id
inner join City c on a.CityId = c.Id
inner join Airport ad on w.AirportDestinyId = ad.Id
inner join City cd on ad.CityId = cd.Id
inner join TravelFlight tf on tf.TravelId = t.Id
inner join Flight f on tf.FlightId = f.Id
inner join Airline ar on f.AirlineId = ar.Id
where 1=1
--and t.id in (1,3)
group by ti.id,
	ti.Description,
	ti.TravelId,
	ti.Price

select
distinct
	a.*
from travel t
inner join way w on t.wayid = w.id
inner join Airport a on w.AirportId = a.Id
inner join City c on a.CityId = c.Id

select
distinct
	a.*
from travel t
inner join way w on t.wayid = w.id
inner join Airport a on w.AirportDestinyId = a.Id
inner join City c on a.CityId = c.Id

select * from travel t
select * from ticket t
select * from flight f
select * from travelflight tf

select * from ticket t
inner join travel tr on t.TravelId = tr.Id
inner join way w on tr.WayId = w.Id
inner join TravelFlight tf on tr.Id = tf.Travel_Id
inner join Flight f on tf.Flight_Id = f.Id