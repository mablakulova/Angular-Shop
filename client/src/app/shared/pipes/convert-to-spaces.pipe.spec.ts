import { ConvertToSpacesPipe } from './convert-to-spaces.pipe';

describe('ConvertToSpacesPipe', () => {
  it('create an instanve', () => {
    const pipe = new ConvertToSpacesPipe();

    expect(pipe).toBeTruthy();
  });

  it('should replace correctly', () => {
    const pipe = new ConvertToSpacesPipe();

    const converted = pipe.transform('gdn-0011', '-');

    expect(converted).toBe('gdn 0011');
  });
});
