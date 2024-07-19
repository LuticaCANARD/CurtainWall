namespace ScheduleController
#light

    open System
    open System.IO
    type Schedule = 
        struct 
            val expireTime: DateTime
            val name : string
        end


    [<Class>]
    module ScheduleControllerModule =
        let isExpired(target:Schedule) = 
            target.expireTime < DateTime.Now
        let isVaild(target:Schedule) =
            not (isExpired target)

        type ScheduleControllerModule(froms:seq<Schedule>) =

            member this.Datas:List<Schedule> = Seq.toList froms;

            member this.AddSchedule(adder:Schedule) = 
                this.Datas = List.sortBy (fun ele -> ele.expireTime) this.Datas;


            member this.GetExpiredSchdule() =
                this.Datas |> List.filter isExpired;

            member this.UpdateSchedule() = 
                let expired = this.GetExpiredSchdule(); 
                let news = this.Datas |> List.filter isVaild; 
                ignore (this.Datas = news)
                expired;

            new() = 
                ScheduleControllerModule(list.Empty);
             

            
            
            
    