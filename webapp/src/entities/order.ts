import { OrderItem } from "./order-item"

export interface Order {
    id?:number
    firstName?:string
    lastName?:string,
    streetAddress?:string,
    postalCode?:string,
    city?:string
    orderStatus?:string
    orderItems?:OrderItem[]
}