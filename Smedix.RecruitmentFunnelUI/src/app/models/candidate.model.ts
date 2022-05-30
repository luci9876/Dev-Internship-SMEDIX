import { CandidateFile } from "./candidate-file.model";
import { Role } from "./role.model";
import { Status } from "./status.model";
import { Technology } from "./technology.model";

export interface Candidate {
    id?: number;
    name?: string;
    lastStatus?: Status;
    role?: Role;
    technology?: Technology;
    lastUpdated?: Date;
    candidateFiles?:CandidateFile[];
}