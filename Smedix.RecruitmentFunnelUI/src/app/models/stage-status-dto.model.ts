import { Status } from "./status.model";

export interface StageStatusDto {
    id:number;
    name:string;
    statuses: Status[];
}