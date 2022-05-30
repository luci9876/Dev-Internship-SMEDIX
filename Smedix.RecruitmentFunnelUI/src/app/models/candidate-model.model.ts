import { CandidateFile } from "./candidate-file.model";
import { CandidateTechnology } from "./candidateTechnology.model";
import { Role } from "./role.model";
import { Status } from "./status.model";
import { Technology } from "./technology.model";

export interface CandidateModel {
    id: number
    name: string;
    email:string;
    phone: string;
    address: string;
    company: string;
    yearsOfExperience: string;
    linkedIn: string;
    notes: string;
    referredBy: string;
    lastUpdated: string;
    role?: Role;
    technology?:Technology;
    source: string;    
    candidateStatus?: Status;
    candidateFiles?:CandidateFile[];
    candidateTechnologies?:CandidateTechnology[];
}