import { AngularSpaProjectPage } from './app.po';

describe('angular-spa-project App', () => {
  let page: AngularSpaProjectPage;

  beforeEach(() => {
    page = new AngularSpaProjectPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
