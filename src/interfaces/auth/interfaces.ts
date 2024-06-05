import type { AuthCardType } from "./types";

export interface IAuthCardProps {
    type:AuthCardType,
    rightPosition?:string
} 

export interface IAuthReferralForm{
    textButton:string,
    label:string
}