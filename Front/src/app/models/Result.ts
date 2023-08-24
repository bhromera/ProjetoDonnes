import { Status } from "./Enums";

export interface Result<T> {
    status: Status;
    message: string;
    value: T;
}
