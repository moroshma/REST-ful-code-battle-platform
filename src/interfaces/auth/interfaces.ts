import type { AuthCardType } from "./types";

export interface IAuthCardProps {
    type:AuthCardType,
    leftPositionCard?:string
} 

export interface IAuthReferralForm{
    textButton:string,
    label:string
}