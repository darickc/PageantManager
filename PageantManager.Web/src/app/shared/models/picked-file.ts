import { ReadMode } from './read-mode';

export class PickedFile {
  lastModifiedDate: Date;
  name: string;
  size: number;
  type: string;
  readMode: ReadMode;
  content: string;

  constructor(
    lastModifiedDate: Date,
    name: string,
    size: number,
    type: string,
    readMode: ReadMode,
    content: any
  ) {
    this.lastModifiedDate = lastModifiedDate;
    this.name = name;
    this.size = size;
    this.type = type;
    this.readMode = readMode;
    this.content = content;
  }
}
