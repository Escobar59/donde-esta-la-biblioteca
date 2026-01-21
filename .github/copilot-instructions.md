# Copilot Instructions

## General Guidelines
- Use `host.Services.GetRequiredService<Interface>()` in `Main` to retrieve services directly from the DI container, avoiding unnecessary scope creation and manual instantiation of concrete classes. 

## Code Style
- Follow specific formatting rules.
- Adhere to naming conventions. 

## Project-Specific Rules
- Ensure that all services are accessed through the DI container to maintain consistency and reduce complexity.