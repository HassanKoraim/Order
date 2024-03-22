# Order Solution

## Description
The Order Solution project contains classes related to managing orders, including the Order and Products classes, and custom validators.

## Order Class
The `Order` class represents an order. It contains the following properties:

- **OrderNo**: An integer representing the order number, random number between 1 and 99999.
- **OrderDate**: The date of the order.
- **InvoicePrice**: The price of the invoice, that representing the total cost of all products in the order.
- **product**: A list of products associated with the order.

### Validation
- **Order Date**: The order date should be greater than or equal to a specified minimum date (default: yesterday) and less than or equal to a specified maximum date (default: today).
- **Invoice Price**: The invoice price should be equal to the total cost of all products in the order.
  
## Products class
The `Products` class represents the product or [list of products] in the order. It contains the following properties:.
- **ProductCode**: An integer representing the product code
- **price**: An integer representing the Price for the product
- **Quantity**: An integer represnting the quantity of the same product.

## Custom Validators
### MinimumDateValidatorAttribute
This class is used to validate the minimum date of the order. The default minimum date is yesterday, and the default maximum date is today.

#### Properties
- **MinimumDate**: The minimum date allowed for the order.
- **MaximumDate**: The maximum date allowed for the order.
- **DefaultErrorMessage**: The default error message template for validation failures.

#### Constructors
- **Default**: Sets the minimum date to yesterday and the maximum date to today by default on the empty constructor.
- **WithMinimumDate**: Sets the minimum date to the provided date.
- **WithMinimumAndMaximumDate**: Sets both the minimum and maximum dates.
#### Usage
```csharp
[MinimumDateValidator]
public DateTime? OrderDate { get; set; }
```

### InvoicePriceValidatorAttribute
This calss is used to validate the InvoicePrice for order to the total price (price * quantity) for all products.
### Properties
- **DefaultErrorMessage**: The default error message template for validation failures.

### Usage
```csharp
[InvoicePriceValidator]
public double? InvoicePrice { get; set; }
```






