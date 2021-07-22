const { describe } = require("mocha");
const { assert } = require("chai");
const { chromium } = require("playwright-chromium");

describe("End to End tests", () => {
  let baseUrl = "http://127.0.0.1:5500/02.Book-Library/index.html";
  let browser;
  let page;
  let mockBaseContent;

  before(async () => {
    browser = await chromium.launch();
  });
  after(async () => {
    browser = await browser.close();
  });
  beforeEach(async () => {
    mockBaseContent = {
      1: { author: "Peter", title: "lorem ipsum 1" },
      2: { author: "Pesho", title: "lorem ipsum 2" },
      3: { author: "Gosho", title: "lorem ipsum 3" },
      4: { author: "Mariyka", title: "lorem ipsum 4" },
    };
    page = await browser.newPage();
    await page.goto(baseUrl);
  });
  afterEach(async () => {
    await page.close();
  });

  it("load books", async () => {
    let fakeRes = {
      status: 200,
      headers: {
        "Access-Control-Allow-Origin": "*",
        "Content-Type": "application/json",
      },
      body: JSON.stringify(mockBaseContent),
    };

    await page.route("**/jsonstore/collections/books", (x) => x.fulfill(fakeRes));

    let [res] = await Promise.all([
      page.waitForResponse("**/jsonstore/collections/books"),
      page.click("#loadBooks"),
    ]);
    res = await res.json();

    assert.deepEqual(res, mockBaseContent);
  });

  it("add books", async () => {
    let mockBook = { title: "pesho", author: "gosho", _id: "5" };
    let fakeRes = {
      status: 200,
      headers: {
        "Access-Control-Allow-Origin": "*",
        "Content-Type": "application/json",
      },
      body: JSON.stringify(mockBook),
    };
    await page.route("**/jsonstore/collections/books", (route) => {
      let sent = route.request().postData();
      assert.deepEqual(JSON.parse(sent), { title: "pesho", author: "gosho" });
      route.fulfill(fakeRes);
    });

    await page.fill('input[name="title"]', mockBook.title);
    await page.fill('input[name="author"]', mockBook.author);

    let [res] = await Promise.all([
      page.waitForResponse("**/jsonstore/collections/books"),
      page.click("#createForm > button"),
    ]);

    res = await res.json();

    assert.deepEqual(res, mockBook);
  });

  it("edit books", async () => {
    let bookList = {
      original: { id: "3", book: { author: "Gosho", title: "lorem ipsum 3" } },
      edited: { author: "Gosho Goshov", title: "lorem ipsum dolor 4" },
    };

    let respList = {
      fillTable: {
        status: 200,
        headers: {
          "Access-Control-Allow-Origin": "*",
          "Content-Type": "application/json",
        },
        body: JSON.stringify(mockBaseContent),
      },
      edit: {
        status: 200,
        headers: {
          "Access-Control-Allow-Origin": "*",
          "Content-Type": "application/json",
        },
        body: JSON.stringify(bookList.edited),
      },
      original: {
        status: 200,
        headers: {
          "Access-Control-Allow-Origin": "*",
          "Content-Type": "application/json",
        },
        body: JSON.stringify(mockBaseContent[3]),
      },
    };

    await page.route("**/jsonstore/collections/books", (x) => x.fulfill(respList.fillTable));

    await Promise.all([
      page.waitForResponse("**/jsonstore/collections/books"),
      page.click("#loadBooks"),
    ]);

    await page.route("**/jsonstore/collections/books/**", (route) => {
      let replies = {
        get: respList.original,
        put: respList.edit,
        delete: respList.del,
      };

      let method = route.request().method();
      route.fulfill(replies[method.toLowerCase()]);
    });

    let [create, edit] = await Promise.all([
      page.isVisible("form#createForm"),
      page.isVisible("form#editForm"),
    ]);

    assert.equal(create, true);
    assert.equal(edit, false);

    await page.click('tr[data-id="3"] button.editBtn');

    [create, edit] = await Promise.all([
      page.isVisible("form#createForm"),
      page.isVisible("form#editForm"),
    ]);

    assert.equal(create, false);
    assert.equal(edit, true);

    let [tit, auth] = await Promise.all([
      page.$eval('#editForm > input[name="title"]', (el) => el.value),
      page.$eval('#editForm > input[name="author"]', (el) => el.value),
    ]);

    assert.equal(tit, bookList.original.book.title);
    assert.equal(auth, bookList.original.book.author);

    await page.fill('#editForm > input[name="title"]', bookList.edited.title);
    await page.fill('#editForm > input[name="author"]', bookList.edited.author);

    await page.click("#editForm > button");

    [tit, auth] = await Promise.all([
      page.$eval('#editForm > input[name="title"]', (el) => el.value),
      page.$eval('#editForm > input[name="author"]', (el) => el.value),
    ]);

    assert.equal(tit, "");
    assert.equal(auth, "");
  });

  it("delete books", async () => {
    let bookList = {
      original: { id: "3", book: { author: "Gosho", title: "lorem ipsum 3" } },
      deleted: { author: "Gosho", title: "lorem ipsum 3" },
    };

    let respList = {
      fillTable: {
        status: 200,
        headers: {
          "Access-Control-Allow-Origin": "*",
          "Content-Type": "application/json",
        },
        body: JSON.stringify(mockBaseContent),
      },
      del: {
        status: 200,
        headers: {
          "Access-Control-Allow-Origin": "*",
          "Content-Type": "application/json",
        },
        body: JSON.stringify(bookList.deleted),
      },
      original: {
        status: 200,
        headers: {
          "Access-Control-Allow-Origin": "*",
          "Content-Type": "application/json",
        },
        body: JSON.stringify(mockBaseContent[3]),
      },
    };

    await page.route("**/jsonstore/collections/books*", (route) => {
      let replies = {
        get: respList.fillTable,
        delete: respList.del,
      };

      let method = route.request().method();
      route.fulfill(replies[method.toLowerCase()]);
    });

    await Promise.all([
      page.waitForResponse("**/jsonstore/collections/books*"),
      page.click("#loadBooks"),
    ]);

    page.on("dialog", (dialog) => {
      dialog.accept();
    });

    await page.route("**/jsonstore/collections/books/3", (route) => {
      assert.equal(route.request().method(), "DELETE");
      route.fulfill(respList.del);
    });

    await page.click('tr[data-id="3"] button.deleteBtn');
  });
});