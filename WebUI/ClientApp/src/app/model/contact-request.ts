export class ContactRequest {
  constructor(
    public fullName: string,
    public email: string,
    public subject: string,
    public body: string,
    public captchaRequest: string,
  ) {}
}
