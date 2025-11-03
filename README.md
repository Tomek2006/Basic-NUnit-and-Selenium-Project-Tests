# Carfax Interview - Selenium Automation Framework

## 🎯 Overview
Automated testing framework built with C#, Selenium WebDriver, and NUnit demonstrating Page Object Model design pattern.

## 🛠️ Technologies
- C# 
- Selenium WebDriver 
- NUnit 
- Page Object Model (POM)
- Visual Studio 2022

## 📁 Project Structure
```
CarfaxInterviewProject/
├── Pages/
│   ├── LoginPage.cs        # Login page objects and actions
│   └── ProductsPage.cs     # Products page objects and actions
├── Tests/
│   ├── LoginTests.cs       # Login functionality tests (3 tests)
│   └── ProductTests.cs     # Product functionality tests (3 tests)
```

## ✅ Test Scenarios

### Login Tests
- ✓ Valid login with correct credentials
- ✓ Invalid login error handling
- ✓ Empty credentials validation

### Product Tests
- ✓ Add product to cart
- ✓ Remove product from cart
- ✓ Show remove button

**Total: 5 tests, all passing ✅**

## 🚀 How to Run

### Prerequisites
- Visual Studio 2022
- .NET 6 SDK
- Chrome browser

### Steps
1. Clone repository
2. Open in Visual Studio
3. Restore NuGet packages
4. Run: Test → Run All Tests

## 🎯 Key Features
- Page Object Model for maintainability
- AAA test pattern (Arrange-Act-Assert)
- Proper SetUp/TearDown lifecycle
- Clear assertion messages
- Test categorization

---

**Built for Carfax Canada technical interview**  
