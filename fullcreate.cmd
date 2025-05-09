@echo off
HappliScaffolder.CLI.exe add-controller-for -f Supplier
HappliScaffolder.CLI.exe add-controller-for -f Order
HappliScaffolder.CLI.exe add-controller-for -f Site
HappliScaffolder.CLI.exe add-controller-for -f Product

HappliScaffolder.CLI.exe add-business-for -f Supplier
HappliScaffolder.CLI.exe add-dal-for -f Supplier
HappliScaffolder.CLI.exe add-concurrency-for -f Supplier

HappliScaffolder.CLI.exe add-business-for -f Order
HappliScaffolder.CLI.exe add-dal-for -f Order
HappliScaffolder.CLI.exe add-concurrency-for -f Order

HappliScaffolder.CLI.exe add-business-for -f Site
HappliScaffolder.CLI.exe add-dal-for -f Site
HappliScaffolder.CLI.exe add-concurrency-for -f Site

HappliScaffolder.CLI.exe add-business-for -f Product
HappliScaffolder.CLI.exe add-dal-for -f Product
HappliScaffolder.CLI.exe add-concurrency-for -f Supplier


