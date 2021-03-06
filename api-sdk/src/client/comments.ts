import Comment from "../models/comment";
import Client from "./client";

export default class Comments {
  constructor(private client: Client) {}

  public async get(): Promise<Comment[]>;
  public async get(id: number): Promise<Comment>;
  public async get(id?: number) {
    if (id) {
      return await new Comment({ client: this.client, id }).fetch();
    } else {
      const data = await this.client.get("/comments");
      return data.map((d: any) => new Comment({ client: this.client, ...d }));
    }
  }
}
