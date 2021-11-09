import { Cart } from "../Model/cart"
import { Home } from "../Model/home"
import { MAbout } from "../Model/m-about"
import { MPurchase } from "../Model/m-purchase"
import { Products } from "../Model/products"


export const Pcart : Array<Cart> = [
  {id:'first pursch',name:'maor',quantity:1,price:'what the price',image:"dcsc"}
]
export const Phome : Array<Home> = [
  {featuredproduct:'recommended product',addtocart:'button add cart',describe:'describe product'}
]
export const Pproducts : Array<Products> = [
  {product:'product',image:'url of image',price:'price product',descripation:'product discount'}
]
export const Ppurchase : Array<MPurchase> = [
  {description:'product',image:'url of image',name:'price product',title:'product discount'}
]
export const Pabout : Array<MAbout> = [
  {description:'product',image:'url of image',companyName:'price product',title:'product discount'}
]
