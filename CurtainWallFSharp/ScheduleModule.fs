namespace ScheduleController
#light // ; 생략을 위한 컴파일러 지시문

    open System
    open System.IO
    // 스케쥴을 나타내는 type
    type Schedule = 
        struct 
            val startTime: DateTime // 일정이 시작하는 시간
            val expireTime: DateTime // 일정이 끝나는 시간
            val name : string // 일정의 이름
        end
    
    [<Class>]
    // 스케쥴을 관리하는 모듈
    module ScheduleController =
        
        // 일정이 만료되었는지 확인한다.
        let isExpired(target:Schedule) = 
            target.expireTime < DateTime.Now
        
        // 현재시점에서 유효한 스케쥴인지 확인한다.
        let isVaild(target:Schedule) =
            not (isExpired target)
        
        // 스케쥴을 관리해주는 type
        type ScheduleController(froms:seq<Schedule>) =

            member this.Datas:List<Schedule> = Seq.toList froms;

            // 스케쥴을 추가한다.
            member this.AddSchedule(adder:Schedule) = 
                this.Datas = List.sortBy (fun ele -> ele.expireTime) this.Datas;

            (* 만료된 스케쥴을 반환한다. *)
            member this.GetExpiredSchdule() =
                this.Datas |> List.filter isExpired;

            (*
                스케쥴을 업데이트 한다. 
                만료된 스케쥴을 제거하고, 유효한 스케쥴만 남긴다.
                만료된 스케쥴을 반환한다.
            *)
            member this.UpdateSchedule() = 
                let expired = this.GetExpiredSchdule(); 
                let news = this.Datas |> List.filter isVaild; 
                this.Datas = news |> ignore
                expired;

            new() = // 매개변수가 없는 경우 빈 리스트로 초기화.
                ScheduleController(list.Empty);
             

            
            
            
    