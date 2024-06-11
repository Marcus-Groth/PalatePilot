import type { CartItem } from "./cartItem";

export interface Cart {
    id: number;
    userId: string;
    cartItems: CartItem[];
    subTotal: number;
}

