import Post from "../models/post";
import Client from "./client";

export default class Posts {
  constructor(private client: Client) {}

  public async get(): Promise<Post[]>;
  public async get(id: number): Promise<Post>;
  public async get(id?: number) {
    if (id) {
      const data = await this.client.get("/posts/" + id);
      return new Post({ client: this.client, ...data });
    } else {
      const data = await this.client.get("/posts");
      return data.map((d: any) => new Post({ client: this.client, ...d }));
    }
  }

  public async create({ title, body }: { title: string; body: string }) {
    const data = await this.client.post("/posts", {
      title,
      body,
      author: this.client.user.id,
    });
    return data;
  }
}