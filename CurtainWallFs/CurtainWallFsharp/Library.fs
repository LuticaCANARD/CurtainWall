namespace ScheduleController
#light

    open System
    open System.Collections.Generic;
    open System.IO
    type Schedule = 
        struct 
            val expireTime: DateTime
            val name : string
        end


    [<Class>]
    module ScheduleControllerModule =

    // 여기에서는 스케쥴 관리를 한다.

        type ScheduleControllerModule(origin:list<Schedule>) =

            let IsVaildSchedule(ele:Schedule) =
                ele.expireTime >= DateTime.Now

            let IsNotVaildSchedule(ele:Schedule) =
                ele.expireTime < DateTime.Now

            member this.Datas:list<Schedule> = origin;

            member this.AddSchedule(adder:Schedule) =
                this.Datas = List.sortBy (fun (ele: Schedule)->ele.expireTime) (adder :: this.Datas) |> ignore
                this.Datas

            member this.GetExpiredSchdule() =
                let ret = List.filter IsNotVaildSchedule this.Datas
                this.Datas = List.filter IsVaildSchedule this.Datas |> ignore;
                ret
                
            new() = ScheduleControllerModule(list.Empty);
            //
            
            
    